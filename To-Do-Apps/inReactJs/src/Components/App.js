import React, { Component } from 'react';
import TodoLI from './TodoLI';
import Data from './Data';

class App extends Component {
  constructor() {
    super();
    this.state = {
      todoList: Data
    }
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(id) {
    this.setState(prevState => {
      const updatedTodos = prevState.todoList.map(todo => {
        if (todo.id === id) {
          todo.completed = !todo.completed
        }
        return todo
      });
      return {
        todoList: updatedTodos
      }
    });
  }

  render() {
    const todoItems = this.state.todoList.map(item => <TodoLI key={item.id} item={item} handleChange={this.handleChange} />)
    return (
      <div className="App">
        <header>
          <h1>
            TODO App
          </h1>
        </header>
        <div className="todo-list">
          {todoItems}
        </div>
      </div>
    );
  }
}

export default App;
