import { useEmForms, required, EmFormGroup, EmFormControl, EmFormErrorMessage } from '@enfometa/em-forms';
import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import UserService from '../services/UserService';

function Login() {
    const userService = new UserService();
    const navigate = useNavigate();
    const emForms = useEmForms({
        forms: [
            {
                name: "username",
                value: "",
                validators: [{ name: "required", func: required, message: "Enter username" }]
            },
            {
                name: "password",
                value: "",
                validators: [{ name: "required", func: required, message: "Enter password" }]
            }
        ]
    })

    const authenticate = async () => {
        if (emForms.validate()) {
            var cred = emForms.toModel();
            try {
                var result = await userService.authenticate(cred);
                localStorage.setItem('token', result.data.token);
                navigate("/home")
            }
            catch (exp) {
                alert("Invalid username or password");
            }

        }
    }

    return (
        <div className="wrapper">
            <h2>Login</h2>
            <form>
                <EmFormGroup emForms={emForms}>
                    <div className="input-box">
                        <EmFormControl formName='username'>
                            <input type="text" placeholder="Username" required />
                        </EmFormControl>
                    </div>
                    <div className='form-error'>
                        <EmFormErrorMessage formName='username' />
                    </div>
                    <div className="input-box">
                        <EmFormControl formName='password'>
                            <input type="password" placeholder="Password" required />
                        </EmFormControl>
                    </div>
                    <div className='form-error'>
                        <EmFormErrorMessage formName='password' />
                    </div>
                    <div className="input-box button">
                        <input type="button" value="Sign in" onClick={authenticate} />
                    </div>
                </EmFormGroup>
            </form>

            <div className="text">
                <h3>Dont have account?<Link to="/signup">Register</Link></h3>
            </div>
        </div>
    );
}

export default Login;