//TEST 1
//to Test the app just run command: node src/site.js
//Test Hello World App
// function hello(compiler: string) {
//     console.log(`Hello from ${compiler}`);
// }
// hello('TypeScript');
//Status: Working

//TEST 2
//to Test the app just run command: node src/site.js
//Module Test Hello World App
import { sayHello } from './greet';

console.log(sayHello('TypeScript'));
//Status: Working

// /**
//  * Predefined delays (in milliseconds/ms).
//  */
// export enum Delays {
//     Short = 500,
//     Medium = 2000,
//     Long = 5000,
// }

// /**
//  * Returns a Promise<string> that resolves after given time.
//  *
//  * @param {string} name - A name.
//  * @param {number=} [delay=Delays.Medium] - Number of milliseconds to delay resolution of the Promise.
//  * @returns {Promise<string>}
//  */
// function delayedHello(
//     name: string,
//     delay: number = Delays.Medium,
// ): Promise<string> {
//     return new Promise((resolve: (value?: string) => void) =>
//         setTimeout(() => resolve(`Hello, ${name}`), delay),
//     );
// }

// // Below are examples of using ESLint errors suppression
// // Here it is suppressing missing return type definitions for greeter function

// // eslint-disable-next-line @typescript-eslint/explicit-function-return-type
// export async function greeter(name: string) {
//     return await delayedHello(name, Delays.Long);
// }