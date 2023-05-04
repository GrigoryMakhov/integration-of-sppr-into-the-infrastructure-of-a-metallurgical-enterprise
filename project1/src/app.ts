import React from "react";
import myRequest from "./utils/request";

export async function getInitialState() {
    let user;

    try {
        user = await myRequest('https://localhost:7127/user/Index');
    }
    catch (error) {
        console.log('Ошибка');
    }
    return user;
};