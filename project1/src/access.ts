export default function (initialState: any) {
    // const { userId, role } = initialState;
    const token =  localStorage.getItem('token');
    return {
        isUser: (token ? true : false)
    };
}