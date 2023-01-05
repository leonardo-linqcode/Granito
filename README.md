
# Cálculo de juros composto

Projeto de avaliação técnica para vaga de Desenvolvedor Back-end na Granito.



## Documentação da API de Cálculo
https://granito-calculo-api.azurewebsites.net

#### Retorna valor com juros aplicado

```http
  GET api/calculajuros?valorinicial=&meses=
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `valorinicial` | `decimal` | **Obrigatório**. Valor base para cálculo. |
| `meses` | `int` | **Obrigatório**. Quantidade de meses para cálculo de juros. |

#### Retorna link do projeto no GitHub

```http
  GET api/showmethecode
```

## Documentação da API de Taxas
https://granito-taxas-api.azurewebsites.net

#### Retorna a taxa atual de juros

```http
  GET /api/taxas
```
## Variáveis de Ambiente

Para rodar o projeto `Granito.Calculo.Api`, você vai precisar adicionar as seguintes variáveis de ambiente

`TaxasApiUrl`= https://granito-taxas-api.azurewebsites.net/ ou https://localhost


## Autores

- [@leonardosilva](https://www.github.com/leonardo-linqcode)

