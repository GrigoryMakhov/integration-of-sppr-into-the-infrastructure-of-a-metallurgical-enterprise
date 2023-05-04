import { Link } from "@umijs/max";
import request from "@/utils/request";
import { Button, Form, Input, Space, Table } from "antd";
import { ColumnsType } from "antd/es/table";
import React from "react";

const DocsPage = () => {
  const [dataSource, setDataSource] = React.useState([]);
  const [loading, setLoading] = React.useState(false);

  const getDirections = (data: any) => {
    setLoading(true);
    request("https://localhost:7127/Direction/Index", { method: 'POST', data }).then(result => {
      console.log(result);
      setDataSource(result);
      setLoading(false);
    });
  }
  React.useEffect(() => getDirections({}), []);
  const searchGroupHandler = (data: any) => {
    console.log(data);
    getDirections (data);
  }

  const removeHendler = (id: number) => {
    request(`https://localhost:7127/Direction/${id}`, { method: 'DELETE' }).then(result => {
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
      title: 'Направление подготовки',
      dataIndex: 'name',
    },
    {
      title: 'Действие',
      key: 'action',
      render: (_, record, index) => (
        <>
          <Link to={`/edit/${record.id}`}>Редактировать</Link> {' '}
          <a onClick={() => removeHendler(record.id)}>Удалить</a>
        </>
      )
    },
  ];
  return (
    <div>
      <Space direction="vertical" style={{ marginBottom: '20px' }}>
        <Link to="/create">
          <Button type="primary">Новое направление подготовки</Button>
        </Link>
      </Space>
      <Form layout="inline" onFinish={searchGroupHandler} style={{ marginBottom: '20px' }}>
        <Form.Item name="name">
          <Input placeholder="Название направления" />
        </Form.Item>
        <Button type="primary" htmlType="submit">Искать</Button>
      </Form>
      <Table dataSource={dataSource} columns={columns} loading={loading} />
    </div>
  )
}
export default DocsPage
