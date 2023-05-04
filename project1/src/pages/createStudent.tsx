import FormGroupEdit from "@/components/FormGroupEdit";
import FormStudentEdit from "@/components/FormStudentEdit";
import request from "@/utils/request";
import { Link, useParams, history } from "@umijs/max";
import { Button, Form, Input, Spin, Table } from "antd";
import { ColumnsType } from "antd/es/table";
import React from "react";

const DocsPage = () => {
  const createHendler = (data: any) => {
    console.log(data);
    request(`https://localhost:7127/Student/` , {method: 'PUT', data }).then(result => {
      history.push('/student');
    });
  }

  const [form] = Form.useForm();
  return (
    <>
    <Form onFinish={createHendler}>     
      <FormStudentEdit/>
      <Button htmlType="submit">Создать</Button>
    </Form> 
    </>
  );
};
export default DocsPage;
