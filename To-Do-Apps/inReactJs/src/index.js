import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import './Components/App.css';
import App from './Components/App';
import Footer from './Components/Footer';
//import logo from './logo.svg';
import * as serviceWorker from './serviceWorker';

ReactDOM.render(<App />, document.getElementById('root'));
ReactDOM.render(<Footer />, document.getElementById('myFooter'));
serviceWorker.unregister();
