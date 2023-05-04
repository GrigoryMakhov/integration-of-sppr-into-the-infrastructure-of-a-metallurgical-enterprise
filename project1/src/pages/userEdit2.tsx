import { Link } from "@umijs/max";
import request from "@/utils/request";
import { Button, Form, Input, Space, Table } from "antd";
import { ColumnsType } from "antd/es/table";
import React from "react";
import { useModel } from "@umijs/max";

const DocsPage = () => {

  const { name, setName } = useModel("useUserModel");
 
  const formNextHandler = () => {

  }
  
  return (
    
    <div>
      <div>Вы ввели имя {name}</div>
      
      <Form layout="inline" onFinish={formNextHandler} style={{ marginBottom: '20px' }}>
        <Form.Item name="email">
          <Input placeholder="E-mail" />
        </Form.Item>
        <Button type="primary" htmlType="submit">Продолжить</Button>
      </Form>
    </div>
  );
};
export default DocsPage
