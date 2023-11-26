# Mini Generic Mock API

The Mini Generic Mock API is a minimal API that creates auto-generated basic mock endpoints based on a JSON configuration file. It allows you to quickly set up mock endpoints for testing and development purposes.

## Usage

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/mini-generic-mock-api.git
    cd mini-generic-mock-api
    ```

2. **Customize the JSON Configuration:**

    Edit the `api-schema.json` file to define your desired mock endpoints and their responses.

    ```json
    {
        "/": {
          "GET": {
            "id": 123,
            "name": "Fake Name",
            "isLocked": false,
            "created": "2022-01-04",
            "uniqueIdentifier": "13e6563a-5466-4d38-b727-1204e46c053bb"
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
        },
        "/products": {
          "GET": [
            {
              "id": 1,
              "name": "Product 1",
              "price": 100
            },
            {
              "id": 2,
              "name": "Product 2",
              "price": 200
            }
          ]
        }
    }
    ```

3. **Run the Mock API:**

    ```bash
    dotnet run
    ```

    As in this example the API will be available at `http://localhost:5000`.


3. Access Swagger Documentation:

    Explore the API using Swagger documentation available at [http://localhost:5000/swagger](http://localhost:5000/swagger).

