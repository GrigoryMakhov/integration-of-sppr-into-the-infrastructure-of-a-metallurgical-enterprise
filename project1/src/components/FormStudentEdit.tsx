import request from "@/utils/request";
import { Button, Form, Input, Modal, Select } from "antd";
import React from "react";

export default (props: any) => {

    const [directions, setDirections] = React.useState<[]>();
    const [groups, setGroups] = React.useState<[]>();
    const [institutes, setInstitutes] = React.useState<[]>();
    React.useEffect(() => {
        request("https://localhost:7127/Direction/Index", { method: 'POST', data: {} }).then(result => {
            const directions = result.map(item => {
                return { value: item.id, label: item.name };
            });
            setDirections(directions);
        });

        request("https://localhost:7127/Group/Index", { method: 'POST', data: {} }).then(result => {
            const groups = result.map(item => {
                return { value: item.id, label: item.name };
            });
            setGroups(groups);
        });

        request("https://localhost:7127/Institute/Index", { method: 'POST', data: {} }).then(result => {
            const institutes = result.map(item => {
                return { value: item.id, label: item.name };
            });
            setInstitutes(institutes);
        });

    },[]);

    
        return (
            <>
                <Form.Item name="lastName" label="Фамилия">
                    <Input placeholder="Введите фамилию"/>
                </Form.Item>

                <Form.Item name="firstName" label="Имя">
                    <Input placeholder="Введите имя"/>
                </Form.Item>

                <Form.Item name="middleName" label="Отчество">
                    <Input placeholder="Введите отчество"/>
                </Form.Item>

                <Form.Item name="group" label="Группа">
                    <Select placeholder="Введите группу"
                    options={groups}/>
                </Form.Item>

                <Form.Item name="direction" label="Направление">
                    <Select placeholder="Введите направление"
                    options={directions}/>
                </Form.Item>

                <Form.Item name="institute" label="Институт">
                    <Select placeholder="Введите институт"
                    options={institutes}/>
                </Form.Item>
                
            </>
        );
    }