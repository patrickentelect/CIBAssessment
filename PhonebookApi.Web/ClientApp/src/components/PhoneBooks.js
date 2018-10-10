import React, { Component } from 'react';

export class PhoneBooks extends Component {
  displayName = PhoneBooks.name

  constructor(props) {
    super(props);
    this.state = { phoneBooks: [], loading: true };

    fetch('http://localhost:5000/api/PhoneBooks')
      .then(response => response.json())
      .then(data => {
        this.setState({ phoneBooks: data, loading: false });
      });
  }

  static renderPhoneBooksTable(phoneBooks) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Name</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {phoneBooks.map(phoneBooks =>
            <tr key={phoneBooks.phoneBookId}>
              <td>{phoneBooks.name}</td>
              <td><button>View Entries</button></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : PhoneBooks.renderPhoneBooksTable(this.state.phoneBooks);

    return (
      <div>
        <h1>Phone Books</h1>
        {contents}
      </div>
    );
  }
}
