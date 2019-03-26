/*
bad code
topics.forEach    (element => {
  console.log( element );
});
console.log(`example created on: ${    dateCreatedOn}`);

const dateCreatedOn="March 26, 2019";

var topics = ["eslint", 'prettier', "vscode"    ];

NOTE: change --dev to --global if you want to install dependencies globally and not locally
*/
const topics = ['eslint', 'prettier', 'vscode'];
const dateCreatedOn = 'March 26, 2019';

topics.forEach(element => {
  console.log(element);
});
console.log(`example created on: ${dateCreatedOn}`);
