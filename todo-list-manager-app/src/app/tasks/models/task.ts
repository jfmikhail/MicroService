export class Task {
    id: number;
    description: string = '';
    state: string = 'todo';
    userId:number;
  
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
