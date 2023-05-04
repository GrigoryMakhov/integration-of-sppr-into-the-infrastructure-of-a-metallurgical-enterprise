import FormDirectionEdit from "@/components/FormDirectionEdit";
import FormGroupEdit from "@/components/FormDirectionEdit";
import request from "@/utils/request";
import { Link, useParams, history } from "@umijs/max";
import { Button, Form, Input, Spin, Table } from "antd";
import { ColumnsType } from "antd/es/table";
import React from "react";

const DocsPage = () => {
  const createHendler = (data: any) => {
    console.log(data);
    request(`https://localhost:7127/Direction/` , {method: 'PUT', data }).then(result => {
      history.push('/docs');
    });
  }

  const [form] = Form.useForm();
  return (
    <>
    <Form onFinish={createHendler}>     
      <FormDirectionEdit/>
      <Button htmlType="submit">Создать</Button>
    </Form> 
    </>
  );
};
export default DocsPage;
