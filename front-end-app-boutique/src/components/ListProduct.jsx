import React from 'react';
import { Table, Button, Row, Col, Form } from 'react-bootstrap';
import './ListProduct.css';
import swal from "sweetalert2";


const BaseURL = 'https://localhost:44369/api';
export class ListProduct extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
        this.inputId = React.createRef();
        this.inputName = React.createRef();
        this.inputDescription = React.createRef();
        this.inputPrice = React.createRef();


        this.state = ({
            modalType: '',
            products: [],
            row: {},
            errorView: false,

        })

    }

    componentDidMount() {
        this.loadTable();
    }

    loadTable = async () => {
        try {
            let response = await fetch(`${BaseURL}/Product/GetAll`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (response.status === 200) {
                let data = await response.json();
                this.setState({ products: data.products });
            }
            else if (response.status === 400 || response.status === 404 || response.status === 500) {
                let errorMessage = await response.text();
                if (errorMessage) {
                    swal.fire(
                        "ERROR",
                        errorMessage,
                        "error"
                    ).then(e => {
                        this.setState({ errorView: true });
                    });
                } else {
                    swal.fire(
                        "ERROR",
                        "Ocurrió un error interno al cargar la tabla, intente de nuevo.",
                        "error"
                    ).then(e => {
                        this.setState({ errorView: true });
                    });
                }

            }

        } catch (e) {
            this.setState({ errorView: true });
        }

    }
    cancelModal = () => {
        this.setState({ modalType: '' });
        return;
    }
    add = () => {

        return (
            <div className='modal-product'>
                <div className="modal-dialog modal-lg modal-dialog-scrollable">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className='modal-title px-4'>Agregar producto</h5>
                        </div>
                        <div className='modal-body'>
                            <Row >
                                <Col md={12}>

                                    <Form>
                                    <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Id</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    ref={this.inputId}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Nombre</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    ref={this.inputName}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Descripci&#243;n</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    ref={this.inputDescription}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Precio</label>
                                            </Col>
                                            <Col sm="10">
                                                <input type="number"
                                                    className='form-control'
                                                    ref={this.inputPrice}
                                                />
                                            </Col>
                                        </Form.Group>
                                      
                                    </Form>
                                </Col>
                            </Row>
                        </div>
                        <div className="modal-footer">
                            <Row>
                                <Col className='mb-1 mt-1' md="12">
                                    <Button variant="success" className='mr-1' type='button' onClick={this.handleAdd}>
                                        Guardar
                                    </Button >
                                    <Button variant="secondary" type='button' onClick={this.cancelModal} >
                                        Cancelar
                                    </Button>
                                </Col>
                            </Row>
                        </div>
                    </div>
                </div>
            </div>
        );



    };
    modify = (row) => {
        let productToEdit = {
            name: row.name,
            description: row.description,
            price: row.price,
            id: row.id
        };
        return (
            <div className='modal-product'>
                <div className="modal-dialog modal-lg modal-dialog-scrollable">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className='modal-title px-4'>Modificar producto</h5>
                        </div>
                        <div className='modal-body'>
                            <Row >
                                <Col md={12}>

                                    <Form>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Nombre</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    defaultValue={productToEdit.name}
                                                    ref={this.inputName}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Descripci&#243;n</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    defaultValue={productToEdit.description}
                                                    ref={this.inputDescription}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Precio</label>
                                            </Col>
                                            <Col sm="10">
                                                <input type="number"
                                                    className='form-control'
                                                    defaultValue={productToEdit.price}
                                                    ref={this.inputPrice}
                                                />
                                            </Col>
                                        </Form.Group>
                                    </Form>
                                </Col>
                            </Row>
                        </div>
                        <div className="modal-footer">
                            <Row>
                                <Col className='mb-1 mt-1' md="12">
                                    <Button variant="success" className='mr-1' type='button' onClick={this.handleModify}>
                                        Guardar
                                    </Button >
                                    <Button variant="secondary" type='button' onClick={this.cancelModal} >
                                        Cancelar
                                    </Button>
                                </Col>
                            </Row>
                        </div>
                    </div>
                </div>
            </div>
        );



    };
    delete = (row) => {
        let productToDelete = {
            name: row.name,
            description: row.description,
            price: row.price,
            id: row.id
        };
        return (
            <div className='modal-product'>
                <div className="modal-dialog modal-lg modal-dialog-scrollable">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className='modal-title px-4'>Eliminar producto</h5>
                        </div>
                        <div className='modal-body'>
                            <Row >
                                <Col md={12}>

                                    <h5 style={{ textAlign: 'center', fontWeight: 'bold' }}>
                                        &iquest;Est&aacute; seguro que desea eliminar el siguiente producto?
                                    </h5>

                                    <Form>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Nombre</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    disabled
                                                    className='form-control'
                                                    defaultValue={productToDelete.name}
                                                    ref={this.inputName}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Descripci&#243;n</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    disabled
                                                    className='form-control'
                                                    defaultValue={productToDelete.description}
                                                    ref={this.inputCompany}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Precio</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    disabled
                                                    className='form-control'
                                                    defaultValue={productToDelete.price}
                                                    ref={this.inputPrice}
                                                />
                                            </Col>
                                        </Form.Group>
                                    </Form>
                                </Col>
                            </Row>
                        </div>
                        <div className="modal-footer">
                            <Row>
                                <Col className='mb-1 mt-1' md="12">
                                    <Button variant="danger" className='mr-1' type='button' onClick={this.handleDelete}>
                                        Eliminar
                                    </Button >
                                    <Button variant="secondary" type='button' onClick={this.cancelModal} >
                                        Cancelar
                                    </Button>
                                </Col>
                            </Row>
                        </div>
                    </div>
                </div>
            </div>
        );



    };

    handleAdd = async (e) => {
        e.preventDefault();
        let product = {};
        product.name = this.inputName.current.value;
        product.description = this.inputDescription.current.value;
        product.price = Number(this.inputPrice.current.value);
        product.id = this.inputId.current.value;
       
        try {
            const response = await fetch(`${BaseURL}/Product/Add`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(product),
            });
            this.setState({ modalType: '' });
            if (response.status === 200) {
                swal.fire(
                    "ÉXITO",
                    "Producto agregado con éxito.",
                    "success"
                ).then(() => {
                    this.loadTable();
                });
            } else if (response.status === 400 || response.status === 404 || response.status === 500) {
                let errorMessage = await response.text();
                if (errorMessage) {
                    swal.fire(
                        "ERROR",
                        errorMessage,
                        "error"
                    ).then(() => {
                        this.loadTable();
                    });
                } else {
                    swal.fire(
                        "ERROR",
                        "Ocurrió un error al agregar el producto, intente de nuevo",
                        "error"
                    );
                }
            }
        } catch (error) {
            swal.fire(
                "ERROR",
                "Ocurrió un error interno, intente de nuevo.",
                "error"
            );

        }
    };
    handleModify = async (e) => {
        e.preventDefault();
        let { row } = this.state;
        row.name = this.inputName.current.value;
        row.description = this.inputDescription.current.value;
        row.price = Number(this.inputPrice.current.value);
        try {
            const response = await fetch(`${BaseURL}/Product/Update`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(row),
            });
            this.setState({ modalType: '' });
            if (response.status === 200) {
                swal.fire(
                    "ÉXITO",
                    "Producto modificado con éxito.",
                    "success"
                ).then(() => {
                    this.loadTable();
                });
            } else if (response.status === 400 || response.status === 404 || response.status === 500) {
                let errorMessage = await response.text();
                if (errorMessage) {
                    swal.fire(
                        "ERROR",
                        errorMessage,
                        "error"
                    ).then(() => {
                        this.loadTable();
                    });
                } else {
                    swal.fire(
                        "ERROR",
                        "Ocurrió un error al modificar el Producto, intente de nuevo",
                        "error"
                    );
                }
            }
        } catch (error) {
            swal.fire(
                "ERROR",
                "Ocurrió un error interno, intente de nuevo.",
                "error"
            );

        }
    };

    handleDelete = async (e) => {
        e.preventDefault();
        let { row } = this.state;
        let deleteProductRequest = {};
        deleteProductRequest.id = row.id;
        try {
            const response = await fetch(`${BaseURL}/Product/Delete`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(deleteProductRequest),
            });
            this.setState({ modalType: '' });
            if (response.status === 200) {
                swal.fire(
                    "ÉXITO",
                    "Producto eliminado con éxito.",
                    "success"
                ).then(() => {
                    this.loadTable();
                });
            } else if (response.status === 400 || response.status === 404 || response.status === 500) {
                let errorMessage = await response.text();
                if (errorMessage) {
                    swal.fire(
                        "ERROR",
                        errorMessage,
                        "error"
                    ).then(() => {
                        this.loadTable();
                    });
                } else {
                    swal.fire(
                        "ERROR",
                        "Ocurrió un error al eliminar el Producto, intente de nuevo",
                        "error"
                    );
                }
            }
        } catch (error) {
            swal.fire(
                "ERROR",
                "Ocurrió un error interno, intente de nuevo.",
                "error"
            );

        }
    };

    conditionalModalRender = () => {
        const { modalType } = this.state;
        const { row } = this.state;
        switch (modalType) {
            case "Modify": {
                return this.modify(row);
            }
            case "Delete": {
                return this.delete(row);
            }
            case "Add": {
                return this.add();
            }
            default:
                return <></>;
        }
    };
    renderTable = () => {
        return this.state.products.map((product, index) => {
            const { id, description, name, price } = product;
            return (
                <tr key={id}>
                    <td>{id}</td>
                    <td>{name}</td>
                    <td>{description}</td>
                    <td>{price}</td>
                    <td>
                        <Button className='mr-1' onClick={() => {
                            this.setState({ modalType: 'Modify' });
                            this.setState({ row: product });
                        }} variant="warning">Editar</Button>
                        <Button onClick={() => {
                            this.setState({ modalType: 'Delete' });
                            this.setState({ row: product });
                        }} variant="danger">Eliminar</Button>
                    </td>
                </tr>
            )
        })
    };

    render() {
        let { errorView } = this.state;

        if (errorView === true) {
            return (
                <h1>No se encuentran datos.</h1>
            );
        } else {
            return (
                <>
                    <Row>
                        <Col md={1}></Col>

                        <Col md={10}>
                            <h1 style={{ textAlign: 'left' }} >Lista de Productos</h1>
                            <hr className='line' />
                        </Col>
                    </Row>
                    <Row>
                        <Col md={1}></Col>
                        <Col md={10}>
                            <Table striped bordered hover >
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Nombre</th>
                                        <th>Descripci&#243;n</th>
                                        <th>Precio</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {this.renderTable()}
                                </tbody>
                            </Table>
                            <Button onClick={() => {
                                this.setState({ modalType: 'Add' });
                            }} variant="primary" > Nuevo</Button>
                        </Col>

                    </Row>
                    {
                        this.conditionalModalRender()
                    }
                </>
            );
        }

    }

}
