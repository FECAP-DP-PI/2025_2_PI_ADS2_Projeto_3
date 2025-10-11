# Etapa 1: build do app React
FROM node:20-alpine AS build
WORKDIR /app
COPY package*.json ./

# Limpar possíveis caches e instalar dependências do zero
RUN rm -rf node_modules package-lock.json
RUN npm install

COPY . .

RUN npm run build

# Etapa 2: servir com Nginx
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
