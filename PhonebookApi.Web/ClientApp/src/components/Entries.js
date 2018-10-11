import React, { Component } from 'react';
import { NavLink } from 'react-router-dom'
import ReactTable from "react-table";
import matchSorter from 'match-sorter';

export class Entries extends Component {
  displayName = Entries.name

  constructor(props) {
    super(props);
    this.state = { entries: [], loading: true };

    var phoneBookId = this.props.match.params.phoneBookId;

    fetch(`http://localhost:5000/api/Entries/EntriesByPhoneBookId/${phoneBookId}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ entries: data, loading: false });
      });
  }

  static renderEntriesTable(entries) {
    return (
        <ReactTable
          data={entries}
          filterable
          defaultFilterMethod={(filter, row) =>
            String(row[filter.id]) === filter.value}
          columns={[
            {
              columns: [
                {
                  Header: "Name",
                  accessor: "name",
                  filterMethod: (filter, rows) =>
                    matchSorter(rows, filter.value, { keys: ["name"] }),
                  filterAll: true
                },
                {
                  Header: "Phone Number",
                  id: "phoneNumber",
                  accessor: d => d.phoneNumber,
                  filterMethod: (filter, rows) =>
                    matchSorter(rows, filter.value, { keys: ["phoneNumber"] }),
                  filterAll: true
                },
                {
                  Header: "",
                  filterable: false,
                  Cell: row => (
                    <div>
                    <NavLink to={`/edit/${row.original.entryId}`}>
                      Edit
                    </NavLink>
                    </div>
                  )
                }
              ]
            },
          ]}
          defaultPageSize={4}
          className="-striped -highlight"/>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Entries.renderEntriesTable(this.state.entries);

    return (
      <div>
        <h1>Entries</h1>
        <NavLink to={`/create/${this.props.match.params.phoneBookId}`}>
          Create New
        </NavLink>
        {contents}
      </div>
    );
  }
}
