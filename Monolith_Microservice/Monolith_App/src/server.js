const express = require('express');
const sql = require('mssql/msnodesqlv8');
const path = require('path');
require('dotenv').config();

console.log(process.env)
const app = express();
const port = 3000;

// Set up middleware to serve static files
app.use(express.static(path.join(__dirname, 'public')));

// SQL Server configuration
const config = {
    driver:'msnodesqlv8',
    user: process.env.USER,
    password: process.env.PASSWORD,
    server: process.env.SERVER,
    database: process.env.DATABASE,
    options: {
        encrypt:false,
        trustedConnection: false
    }
};

// Create a pool connection
let poolPromise;

const initializeDbConnection = async () => {
    try {
        poolPromise = sql.connect(config);
        console.log('Connected to SQL Server');
    } catch (err) {
        console.error('SQL Server connection error: ', err);
        process.exit(1);
    }
};

initializeDbConnection();

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname,'public', 'index.html'));
});

// Route to fetch course details
app.get('/courses', async (req, res) => {
    try {
        const pool = await poolPromise;
        const result = await pool.request().query('SELECT * FROM CourseDetails');
        res.json(result.recordset);
    } catch (err) {
        console.error('Error fetching courses: ', err);
        res.sendStatus(500);
    }
});

// Start the server
app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}`);
});
