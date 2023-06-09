import { Link } from "@umijs/max";
import request from "@/utils/request";
import { Button, Form, Input, Select, Space, Table } from "antd";
import { ColumnsType } from "antd/es/table";
import React from "react";

const DocsPage = () => {
  const [dataSource, setDataSource] = React.useState([]);
  const [loading, setLoading] = React.useState(false);

  const getStudents = (data: any) => {
    setLoading(true);
    request("https://localhost:7127/Student/Index", { method: 'POST', data }).then(result => {
      console.log(result);
      setDataSource(result);
      setLoading(false);
    });
  }
  
  React.useEffect(() => getStudents({}), []);
  const searchStudetHandler = (data: any) => {
    console.log(data);
    getStudents (data);
  }

  const removeHendler = (id: number) => {
    request(`https://localhost:7127/Student/${id}`, { method: 'DELETE' }).then(result => {
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
      title: 'Фамилия',
      dataIndex: 'lastName',
    },
    {
      title: 'Имя',
      dataIndex: 'firstName',
    },
    {
      title: 'Отчество',
      dataIndex: 'middleName',
    },
    {
      title: 'Группа',
      dataIndex: 'group',
      render: (value, record, index) => value.name
    },
    {
      title: 'Направление',
      dataIndex: 'direction',
      render: (value, record, index) => value.name

    },
    {
      title: 'Институт',
      dataIndex: 'institute',
      render: (value, record, index) => value.name

    },
    {
      title: 'Действие',
      key: 'action',
      render: (_, record, index) => (
        <>
          <Link to={`/editStudent/${record.id}`}>Редактировать</Link> {' '}
          <a onClick={() => removeHendler(record.id)}>Удалить</a>
        </>
      )
    },
  ];
  return (
    <div>
      <Space direction="vertical" style={{ marginBottom: '20px' }}>
        <Link to="/createStudent">
          <Button type="primary">Новая запись</Button>
        </Link>
      </Space>
      <Form layout="inline" onFinish={searchStudetHandler} style={{ marginBottom: '20px' }}>
        <Form.Item name="lastName">
          <Input placeholder="Введите фамилию" />
        </Form.Item>
        <Form.Item name="firstName">
          <Input placeholder="Введите имя" />
        </Form.Item>
        <Form.Item name="middleName">
          <Input placeholder="Введите отчество" />
        </Form.Item>
        <Form.Item name="name">
          <Input placeholder="Введите название группы" />
        </Form.Item>
        <Form.Item name="directionName" style={{ width: '250px' }}>
          <Input allowClear placeholder="Введите направление подготовки" />
        </Form.Item>
        <Form.Item name="instituteName" style={{ width: '250px' }}>
          <Input allowClear placeholder="Введите инститтут" />
        </Form.Item>

        <Button type="primary" htmlType="submit">Искать</Button>
      </Form>
      <Table dataSource={dataSource} columns={columns} loading={loading} />
    </div>
  )
}
export default DocsPage
