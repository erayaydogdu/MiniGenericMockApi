## Mini Generic Mock Api

Minimal API auto generates basic mock api based on json config file below:

```json
{
    "/": {
      "GET": {
        "id": 123,
        "name": "Craig",
        "isLocked": false,
        "created": "2021-11-04",
        "uniqueIdentifier": "14e6563e-6221-4d38-b727-105e46c053bb"
      },
      "POST": {
        "success": true
      }
    },
    "/menu": {
      "GET": [
        {
          "id": 1,
          "name": "Home",
          "slug": "/"
        },
        {
          "id": 2,
          "name": "About",
          "slug": "/about"
        }
      ]
    }
}
```


