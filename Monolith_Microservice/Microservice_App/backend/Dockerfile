# Use the official Node.js image with the specific version
FROM node:20.14.0

# Set the working directory inside the container
WORKDIR /usr/src/app

# Copy the rest of your application code
COPY ./package.json ./

# Install dependencies
RUN npm install

# Install nodemon globally
RUN npm install -g nodemon

# Install sql server for node
RUN npm i msnodesqlv8

COPY . .

# Expose port 3000
EXPOSE 3000

# Command to run the application using nodemon
CMD ["nodemon", "/backend/server.js"]

