const express = require('express')
const app = express()
const port = 3000

app.set('view engine', 'pug')
app.use('/views', express.static('views'));
app.get('/', (req, res) => res.render('index'))

app.listen(3000)