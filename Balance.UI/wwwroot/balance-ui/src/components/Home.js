import React, { useEffect, useState } from 'react';
import UserService from '../services/UserService';

function Home(props) {
    const userService = new UserService();
    const [balance, setBalance] = useState(0.0);

    useEffect(() => {
        userService.balance().then(response => {
            setBalance(response.data.balance);
        })
    }, [])

    return (
        <div>
            <h3>Welcome ! Your balance is: {balance}</h3>
        </div>
    );
}

export default Home;