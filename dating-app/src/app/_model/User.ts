export class User {
    id: number = 0;
    username: string = '';
    email: string = '';

    // /**
    //  *
    //  */
    // constructor(id:number,usrname:string,mail:string) {
    //     this.id = id;
    //     this.username = usrname;
    //     this.email = mail;
    // }
}

export class UserToken {
    username: string = '';
    token: string = '';
}

export class UserRegister {
    username: string = '';
    email: string = '';
    password: string = '';
}