import { defineConfig } from '@umijs/max';

export default defineConfig({
  antd: {},
  access: {},
  model: {},
  initialState: {},
  request: {},
  // layout: {
  //   title: '@umijs/max',
  // },
  routes: [

    {
      path: '/',
      component: './index',
    },
    {
      path: '/auth',
      component: './auth',
    },

    {
      path: '/group',
      component: './group',
    },
    {
      path: '/docs',
      component: './docs',
    },
    {
      path: '/student',
      component: './student',
    },
    {
      path: '/institute',
      component: './institute',
    },
    {
      path: '/create',
      component: './create',
    },
    {
      path: '/createGroup',
      component: './createGroup',
    },
    {
      path: '/createInstitute',
      component: './createInstitute',
    },
    {
      path: '/createStudent',
      component: './createStudent',
    },

    {
      path: '/edit/:id',
      component: './edit/[id]',
    },
    {
      path: '/editGroup/:id',
      component: './editGroup/[id]',
    },
    {
      path: '/editInstitute/:id',
      component: './editInstitute/[id]',
    },
    {
      path: '/editStudent/:id',
      component: './editStudent/[id]',
    },
    {
      path: '/userEdit',
      component: './userEdit',
    },
    {
      path: '/userEdit2',
      component: './userEdit2',
    }
  //   {
  //     path: '/',
  //     redirect: '/home',
  //   },
  //   {
  //     name: '首页',
  //     path: '/home',
  //     component: './Home',
  //   },
  //   {
  //     name: '权限演示',
  //     path: '/access',
  //     component: './Access',
  //   },
  //   {
  //       name: ' CRUD 示例',
  //       path: '/table',
  //       component: './Table',
  //   },
  ],
  npmClient: 'npm',
});

