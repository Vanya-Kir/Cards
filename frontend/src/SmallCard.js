import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';

function SmallCard(props) {

    const [title, setTitle] = useState(props.card.firstTitle);
    const [isImg, setImg] = useState(true);
    const showAlert = () => {
        if (isImg) {
            setImg(false)
            setTitle(props.card.secondTitle);
        }
        else {
            setImg(true)
            setTitle(props.card.firstTitle);
        }
    }

    return (
        <Card>
            <Card.Body>
                <Button variant="primary" onClick={showAlert}>Перевернуть</Button>
                <Card.Title>{title}</Card.Title>

                <div className='img'>
                    {
                        isImg === true
                            ? <Card.Img variant="top" crossOrigin="true" src={props.card.imgUrl} height="200" />
                            : props.card.details
                    }
                </div>
            </Card.Body>
        </Card>
    );
}

export default SmallCard;