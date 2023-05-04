import FormGroupEdit from "@/components/FormDirectionEdit";
import { Link, useParams, history } from "@umijs/max";
import { request } from "@umijs/max";
import { Button, Form, Input, Spin, Table } from "antd";
import { ColumnsType } from "antd/es/table";
import React from "react";

const DocsPage = () => {
  const params = useParams();
  console.log(params); 
  const [data, setData] = React.useState();

  React.useEffect(() => {
    request(`https://localhost:7127/Direction/${params.id}`).then(result => {
      console.log(result);
      setData(result);
      // form.setFieldsValue(result);
    });
  }, []); 

  const editHendler = (data: any) => {
    console.log(data);

    request(`https://localhost:7127/Direction/${params.id}` , {method: 'POST', data }).then(result => {
      history.push('/docs');
    });
  }

  const [form] = Form.useForm();
    return (
    <>
    {data ? <Form onFinish={editHendler} form={form} initialValues={data}>
      <Form.Item name="id" hidden></Form.Item>
      <FormGroupEdit />

      <Button type="primary" htmlType="submit">Сохранить</Button>
    </Form> : <Spin />}
    </>
  );
};
export default DocsPage;
