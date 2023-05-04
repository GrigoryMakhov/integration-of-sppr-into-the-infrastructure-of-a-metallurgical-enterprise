import { Button, Form, Input, Modal } from "antd";
import React from "react";

export default (props: any) => {
 
    return (
        <>
            <Form.Item name="name" label="Название направления">
            <Input />
            </Form.Item>           
        </>
    );
}