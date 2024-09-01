const express = require("express");
const mysql = require("mysql2");
const cors = require("cors");
const path = require("path");

require("dotenv").config();

const app = express();
app.use(cors());
const port = 3000;

const config = {
  user: process.env.DB_USER,
  password: process.env.DB_PASSWORD,
  host: process.env.DB_HOST,
  database: process.env.DB_NAME,
  port: process.env.DB_PORT
};

app.get("/courses", async (req, res) => {
  console.log("------------------------")
  try {
    const pool = mysql.createPool(config).promise();
    const [rows] = await pool.query("SELECT * FROM CourseDetails");
    console.log(rows)
    res.json(rows);
  } catch (err) {
    console.log(err)
    res.status(500).send("Internal server error");
  }
});

app.listen(port, () => {
  console.log(`Server running at http://localhost:${port}`);
});