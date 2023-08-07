const btnBooks = document.getElementById("btn-books");
const btnPublishers = document.getElementById("btn-publishers");
const resultsDiv = document.getElementById("results");

btnBooks.addEventListener('click', () => {
    let response = fetch("http://localhost:5201/api/books")
        .then(res => res.json())
        .then(res => setBooks(res.Data))
        .catch(err => console.log(err));
});

btnPublishers.addEventListener('click', () => {
    let response = fetch("http://localhost:5201/api/publishers")
        .then(res => res.json())
        .then(res => setPublishers(res.Data))
        .catch(err => console.log(err));
});

const setBooks = (books) => {
    resultsDiv.innerHTML = "";
    books.forEach(book => {
        resultsDiv.innerHTML += `
            <div>
                <p class="item" onclick="getBookDetails(${book.Id})">
                    ${book.Name}
                </p>
            </div>
        `;
    });
}

const setPublishers = (publishers)=> {
    resultsDiv.innerHTML = "";
    publishers.forEach(publisher => {
        resultsDiv.innerHTML += `
        <div>
            <p>${publisher.Name}</p>
        </div>
    `;
    });
}
