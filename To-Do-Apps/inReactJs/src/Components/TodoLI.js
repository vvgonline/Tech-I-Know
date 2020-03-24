import React from 'react';

function TodoLI(props){
    return(
        <span className="form-check form-group todo-item">
            <input 
                type="checkbox" 
                className="form-check-input"
                checked={props.item.completed}
                onChange={() => props.handleChange(props.item.id)}
             />
            <label className="form-check-label">
                {props.item.text}
            </label>
        </span>
    );  
}

export default TodoLI;