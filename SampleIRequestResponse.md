# Add Portfolio
# Portfolio Performance API

	Request - "TestPortfolio"



## Add Asset

	Request: portfolioId = 1
	
	{
	  "symbol": "AAPL",
	  "type": "Stock"
	}


## Add Transaction

    Request 1:
	portfolioId = 1, assetId = 1	
	{
	  "date": "2025-07-14T02:47:51.489Z",
	  "type": "Buy",
	  "quantity": 10,
	  "price": 100
	}

    Request 2:
    portfolioId = 1, assetId = 1
    {
      "date": "2025-07-14T02:53:51.004Z",
      "type": "Sell",
      "quantity": 5,
      "price": 120
    }



## Get Portfolios

    Response:
    [
      {
        "id": 1,
        "name": "TestPortfolio",
        "assets": [
          {
            "id": 1,
            "symbol": "AAPL",
            "type": "Stock",
            "transactions": [
              {
                "date": "2025-07-14T02:47:51.489Z",
                "type": "Buy",
                "quantity": 10,
                "price": 100
              },
              {
                "date": "2025-07-14T02:53:51.004Z",
                "type": "Sell",
                "quantity": 5,
                "price": 120
              }
            ]
          }
        ]
      }
    ]



## Retrieve Portfolio Performance

    Request:
    id: 1
    from: 2025-07-01
    to: 2025-07-31


    Response:
    {
      "totalValue": 1000,
      "allocation": {
        "AAPL": 100
      },
      "realizedGain": 0,
      "unrealizedGain": 600
    }