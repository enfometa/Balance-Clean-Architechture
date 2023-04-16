import axios from "axios";

export default class UserService {
    constructor() {
        axios.defaults.baseURL = 'https://localhost:7225'
        const token = localStorage.getItem('token');
        if (token) {
            axios.defaults.headers.common.Authorization = `Bearer ${token}`;
        }

    }

    register(user) {
        return axios.post('/api/users/signup', user);
    }
    authenticate(cred) {
        return axios.post('/api/users/Authenticate', cred);
    }

    balance(cred) {
        return axios.get('/api/users/auth/balance');
    }
}