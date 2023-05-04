import { Button, Modal } from "antd";
import React from "react";

export default (props: any) => {

    console.log(props)
    const [isModalOpen, setIsModalOpen] = React.useState(false);

    const showModal = () => {
        setIsModalOpen(true);
    };

    const handleOk =  () => {
        setIsModalOpen(false);
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };

    return (
            <>
                <Button type="primary" onClick={showModal} >
                    {props.buttonText}
                </Button>

                <Modal title="Basic Modal" open={isModalOpen} onOk={handleOk} onCancel={handleCancel}>
                    <p>123</p>
                    <p>123</p>
                    <p>123</p>
                </Modal>
            </>
    );
}