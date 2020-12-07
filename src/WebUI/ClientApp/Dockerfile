
FROM node:latest
# Create app directory
WORKDIR /usr/src/app
# Install app dependencies
COPY package*.json ./

RUN npm install
# Copy app source code
COPY . .

ARG ENV=docker
ENV ENV ${ENV}

#Expose port and start application
EXPOSE 4200
CMD npm run start-${ENV}