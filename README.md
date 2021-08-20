# Conteinerizando uma aplicação .NET Core

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A ideia central é **_conteinerizar_** um aplicativo .NET Core para desenvolvimento com o Docker Compose. Neste caso, trata-se de uma aplicação para cadastro de produtos.. só isso!

> Todo processo está configurado num arquivo de manifesto (**docker-compose.yaml**) que está na raiz da solução.

### 🔥 Para baixar:

```js
https://github.com/fabioborges-ti/webapi.netcore-mongodb-docker-compose
```

### 📋 Pré-requisitos
Antes de começar, você vai precisar ter instalado as seguintes ferramentas: [Git]([https://git-scm.com](https://git-scm.com/)) e o [Docker]([https://docs.docker.com/desktop/](https://docs.docker.com/desktop/)). Além disto, sugiro que você também utilize um bom editor de código, como o [VSCode]([https://code.visualstudio.com/]  (https://code.visualstudio.com/)). Este vai te oferecer _muitas_ extensões que farão toda diferença.

### 📦 Dependências do projeto
Abra seu terminal na pasta da solução e execute o seguinte comando: 

```bash
$ dotnet restore
```

### 🤞 Vamos testar?
Agora que você já tem tudo... chegou a hora de testar. Novamente, abra seu terminal na pasta **_raiz_** da solução, digite o comando abaixo e aguarde o fim do processo ☕

```bash
$ docker-compose up -d 
```
O **_Docker_** vai baixar do seu repositório https://hub.docker.com todas as imagens mencionadas no arquivo do _compose_ (**_yaml_**). Depois, inicia a geração da imagem e por fim a geração do container. Em poucos instantes nosso container estará de pé 😲

Quando esse processo encerrar, você pode conferir usando o comando abaixo:

```bash
$ docker ps  
```
Atente para os seguintes containers:

```bash
productapi
mongo:5.0.2
```

Se estes foram listados, sucesso! 🤗 Já podemos fazer nossa primeira chamada da API. 

### 📝 Documentação da API

Para acessar a documentação da API e seus recursos, acesse: 

```bash
http://localhost:8080/swagger/index.html
```

## 📚 Para mais informações:

Se você não conhece muito sobre este processo e quer mais detalhes, consulte em:

https://docs.docker.com/compose/

E bom estudos! 🚀

