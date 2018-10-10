import React, { Component } from 'react';

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
      <table className='table'>
        <thead>
          <tr>
            <th>Name</th>
            <th>Phone Number</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {entries.map(entries =>
            <tr key={entries.entryId}>
              <td>{entries.name}</td>
              <td>{entries.phoneNumber}</td>
              <td><button>Edit</button></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Entries.renderEntriesTable(this.state.entries);

    return (
      <div>
        <h1>Entries</h1>
        {contents}
      </div>
    );
  }
}
