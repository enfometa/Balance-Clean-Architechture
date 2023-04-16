import { useEmForms, required, EmFormGroup, EmFormControl, EmFormErrorMessage } from '@enfometa/em-forms';
import React from 'react';
import { Link } from 'react-router-dom';
import UserService from '../services/UserService';

function Signup(props) {
    const userService = new UserService();

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
            },
            {
                name: "firstname",
                value: "",
                validators: [{ name: "required", func: required, message: "Enter first name" }]
            },
            {
                name: "lastname",
                value: "",
                validators: [{ name: "required", func: required, message: "Enter last name" }]
            }
        ]
    })

    const register = async () => {
        if (emForms.validate()) {
            var user = emForms.toModel();
            try {
                var result = await userService.register(user);
                emForms.reset();
                alert("User created")
            }
            catch (exp) {
                alert("User already exists");
            }

        }
    }

    return (
        <div className="wrapper">
            <h2>Registration</h2>
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
                    <div className="input-box">
                        <EmFormControl formName='firstname'>
                            <input type="text" placeholder="First name" required />
                        </EmFormControl>
                    </div>
                    <div className='form-error'>
                        <EmFormErrorMessage formName='firstname' />
                    </div>
                    <div className="input-box">
                        <EmFormControl formName='lastname'>
                            <input type="text" placeholder="Last name" required />
                        </EmFormControl>
                    </div>
                    <div className='form-error'>
                        <EmFormErrorMessage formName='lastname' />
                    </div>
                    <div className="input-box button">
                        <input type="button" value="Register Now" onClick={register} />
                    </div>
                </EmFormGroup>
            </form>

            <div className="text">
                <h3>Already have an account?<Link to="/login">Login now</Link></h3>
            </div>
        </div>
    );
}

export default Signup;