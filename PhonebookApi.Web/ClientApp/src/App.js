import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { PhoneBooks } from './components/PhoneBooks';
import { Entries } from './components/Entries';
import {EditEntry} from './components/EditEntry';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetchdata' component={FetchData} />
        <Route path='/phoneBooks' component={PhoneBooks} />
        <Route path='/entries/:phoneBookId' component={Entries} />
        <Route path='/edit/:entryId' component={EditEntry} />
        <Route path='/create/' component={EditEntry} />
      </Layout>
    );
  }
}
