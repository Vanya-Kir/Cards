import { useState } from 'react';
import { useNavigate } from 'react-router-dom';


function CreateCard() {
    const navigate = useNavigate();
    const [error, setError] = useState("")
    const [data, setData] = useState({
        firstTitle: "",
        secondTitle: "",
        details: "",
        imgUrl: "",
    })

    function submit(e) {
        e.preventDefault();
        const url = "https://localhost:7180/api/Card";

        const getCardList = async () => {

            const response = await fetch(url, {
                method: "post",
                headers: {
                    "Content-Type": "application/json; charset=utf-8"
                },
                body: JSON.stringify(data),
            });
            if (response.ok) {
                navigate('/', { replace: true });
            }
            setError("Ошибка при отправке формы")
        };
        getCardList();

    }

    function handle(e) {
        const newdata = { ...data }
        newdata[e.target.id] = e.target.value
        setData(newdata)
        console.log(newdata)
    }

    return (
        <div className='container'>
            <form onSubmit={(e) => submit(e)}>
                <input type="text" placeholder="firstTitle"
                    onChange={(e) => handle(e)}
                    id="firstTitle"
                    value={data.firstTitle}></input>
                <input type="text" placeholder="secondTitle"
                    onChange={(e) => handle(e)}
                    id="secondTitle"
                    value={data.secondTitle}></input>
                <input type="text" placeholder="details"
                    onChange={(e) => handle(e)}
                    id="details"
                    value={data.details}>
                </input><input type="text" placeholder="imgUrl"
                    onChange={(e) => handle(e)}
                    id="imgUrl"
                    value={data.imgUrl}></input>
                <button type="submit">Отправить</button>
            </form>
            <p>{error}</p>
        </div>
    );
}

export default CreateCard;