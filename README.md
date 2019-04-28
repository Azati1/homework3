# homework3

####Код для создания таблицы

		create table books (id uuid, name text, url text)

####Описание API 

- GetBooks [HttpGet]

	Пример вызова https://localhost:5001/api/books


- GetBook [HttpGet("{id}")]

	Пример вызова https://localhost:5001/api/books/299e9fd9-d02a-4198-9b15-621fa598accd


- CreateBook [HttpPost] (Требуется передать объект book (json) в теле запроса)

	Пример вызова https://localhost:5001/api/books/

		Headers:
		Content-Type - application/json
		
		RequestBody:
		{"name":"Learning Dart - Second Edition","url":"https://www.amazon.com/gp/product/1785287621"}



- UpdateBook [HttpPut] (Требуется передать объект book (json) в теле запроса)

	Пример вызова https://localhost:5001/api/books/

		Headers:
		Content-Type - application/json

		RequestBody:
		{"id":"299e9fd9-d02a-4198-9b15-621fa598accd","name":"Flutter in Action","url":"https://www.manning.com/books/flutter-in-action"}


- DeleteBook [HttpDelete("{id}")]

	Пример вызова https://localhost:5001/api/books/299e9fd9-d02a-4198-9b15-621fa598accd
