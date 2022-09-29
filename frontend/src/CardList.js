import React, { useState, useEffect } from 'react';
import SmallCard from './SmallCard';
function CardList() {

    const [cardList, setCardList] = useState([]);

    useEffect(() => {
        const url = "https://localhost:7180/api/Card";

        const getCardList = async () => {
            const response = await fetch(url);
            const data = await response.json();
            setCardList(data.cards);
        };
        getCardList();

    }, []);

    return (
        <div className="container">
            <div className="row row-cols-3">
                {
                    cardList.map((card, index) => {
                        console.log(card);
                        return <SmallCard card={card} key={index} />
                    })
                }
            </div>
        </div>
    );
}

export default CardList;