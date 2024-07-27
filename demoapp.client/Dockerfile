# Stage 1: Build environment
FROM node:18 AS build-env

# Set working directory
WORKDIR /app

# Install dependencies
COPY package.json ./
COPY package-lock.json ./
RUN npm install

# Copy all other source code
COPY . ./

# Build the application
RUN npm run build

# Stage 2: Serve environment
FROM nginx:alpine

# Copy build files from build-env
COPY --from=build-env /app/build /usr/share/nginx/html

# Expose port
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]