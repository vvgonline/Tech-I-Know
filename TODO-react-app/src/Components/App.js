import React, { Component } from 'react';
import TodoLI from './TodoLI';

class App extends Component {
  render() {
    return (      
      <div className="App">
        <header>
          <h1>
            TODO App
          </h1>
        </header>
        <div className="todo-list">
          <TodoLI />
        </div>
      </div>
    );
  }
}

export default App;
