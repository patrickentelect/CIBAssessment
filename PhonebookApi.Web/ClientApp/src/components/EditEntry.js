import React, { Component } from 'react';
import { FormGroup, ButtonGroup, Button } from 'react-bootstrap';

export class EditEntry extends Component {
    displayName = "Edit Entry"

    constructor(props) {
        super(props);
        this.state = { entry: {}, loading: true };

        var entryId = this.props.match.params.entryId;

        if (entryId) {
            fetch(`http://localhost:5000/api/Entries/${entryId}`)
                .then(response => response.json())
                .then(data => {
                    this.setState({ entry: data, loading: false });
                });
        }

        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        var phonebookId = this.props.match.params.phonebookId;
        if (phonebookId) {
            var emptyEntry = {
                entryId: 0,
                name: "",
                phoneNumber: "",
                phonebookId: phonebookId,
            }
            this.setState({ entry: emptyEntry, loading: false });
        }
    }

    handleSubmit(event) {
        event.preventDefault();

        const data = {}
        Array.prototype.forEach.call(event.target.elements, element => {
            data[element.id] = element.value;
        });

        if (this.state.entry.entryId) {
            fetch('http://localhost:5000/api/Entries', {
                method: 'PUT',
                body: JSON.stringify(data),
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json',
                    'Accept': 'application/json',
                },
            });
        }
        else {
            fetch('http://localhost:5000/api/Entries', {
                method: 'POST',
                body: JSON.stringify(data),
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json',
                    'Accept': 'application/json',
                },
            });
        }
    }

    renderEntryForm(entry) {
        return (
            <form onSubmit={this.handleSubmit}>
                <input type="hidden"
                    id="phonebookId"
                    defaultValue={entry.phonebookId} />
                <FormGroup>
                    <input
                        type="text"
                        id="entryId"
                        defaultValue={entry.entryId}
                        className="form-control"
                        disabled />
                </FormGroup>
                <FormGroup>
                    <input
                        type="text"
                        className="form-control"
                        id="name"
                        placeholder="Name"
                        defaultValue={entry.name} />
                </FormGroup>
                <FormGroup>
                    <input
                        type="text"
                        className="form-control"
                        id="phoneNumber"
                        placeholder="Phone Number"
                        defaultValue={entry.phoneNumber} />
                </FormGroup>
                <ButtonGroup className="pull-right">
                    <Button type="submit" bsStyle="success">Save</Button>
                    <Button bsStyle="danger">Back</Button>
                </ButtonGroup>
                <div style={{ clear: 'both' }}></div>
            </form>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderEntryForm(this.state.entry);

        return (
            <div>
                <h1>Edit Entry</h1>
                {contents}
            </div>
        );
    }
}
