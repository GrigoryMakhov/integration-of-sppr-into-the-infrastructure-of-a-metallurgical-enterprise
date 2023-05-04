import { Link } from "@umijs/max";
import request from "@/utils/request";
import { Button, Form, Input, Space, Table } from "antd";
import { ColumnsType } from "antd/es/table";
import React from "react";

const DocsPage = () => {
  const [dataSource, setDataSource] = React.useState([]);
  const [loading, setLoading] = React.useState(false);

  const getInstitutes = (data: any) => {
    setLoading(true);
    request("https://localhost:7127/Institute/Index", { method: 'POST', data }).then(result => {
      console.log(result);
      setDataSource(result);
      setLoading(false);
    });
  }
  React.useEffect(() => getInstitutes({}), []);
  const searchInstituteHandler = (data: any) => {
    console.log(data);
    getInstitutes (data);
  }

  const removeHendler = (id: number) => {
    request(`https://localhost:7127/Institute/${id}`, { method: 'DELETE' }).then(result => {
      const newDatasource = dataSource.filter((value, index) => value.id != id);
      console.log(newDatasource);
      setDataSource(newDatasource);
    });
  }

  const columns: ColumnsType<never> = [
    {
      title: 'Id',
      dataIndex: 'id',
    },
    {
      title: 'Институт',
      dataIndex: 'name',
    },
    {
      title: 'Действие',
      key: 'action',
      render: (_, record, index) => (
        <>
          <Link to={`/editInstitute/${record.id}`}>Редактировать</Link> {' '}
          <a onClick={() => removeHendler(record.id)}>Удалить</a>
        </>
      )
    },
  ];
  return (
    <div>
      <Space direction="vertical" style={{ marginBottom: '20px' }}>
        <Link to="/createInstitute">
          <Button type="primary">Новый институт</Button>
        </Link>
      </Space>
      <Form layout="inline" onFinish={searchInstituteHandler} style={{ marginBottom: '20px' }}>
        <Form.Item name="name">
          <Input placeholder="Название института" />
        </Form.Item>
        <Button type="primary" htmlType="submit">Искать</Button>
      </Form>
      <Table dataSource={dataSource} columns={columns} loading={loading} />
    </div>
  )
}
export default DocsPage
