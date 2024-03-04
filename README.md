# Sleek Flow TODO Web Api assessment

## Do first

Please run

```
add-migration "migration name here"

update-database
```

Prior before running the api to ensure the database is properly set up.

## Postman Test

Open 'Sleekflow.postman_collection.json' with Postman

Make sure to register(if new user) in using the API
Log into your user. This will generate a token that you will need throughout the testing purpose.

### BEFORE RUNNING ANY CRUD OPERATIONS

Navigate to 'Authorization'
Select type to 'Bearer Token'
Paste the token generated earlier into the token textbox

### 1. Add TODO Item(s)

Follow the JSON format

```
{
  "itemId": 0, //optional as it is a key
  "itemName": "string",
  "itemDescription": "string",
  "dueDate": "2024-03-04T13:46:48.201Z",
  "itemStatus": "string"
}
```

### 2. Get TODO Item(s)
Send the URL to get the list of items.

**SORTING**
For sorting, add `sorts` into the key, followed by the column name into the value. 

`sorts` is a comma-delimited ordered list of property names to sort by. Adding a `-` before the name switches to sorting descendingly.

**FILTERING**
For filtering, add `filters` into the key, followed by column name into the value, and what do you want to filter. Example:

![image](https://github.com/HazmiHaizan/SleekflowAssessmentHazmi/assets/53815205/b773ddc5-df3b-4a76-97a7-ece9dab732f8)

### 3. Update Todo Item

Follow the JSON format, and make sure to specify the itemId that you want to edit in the URL (example: /api/TodoItem/1)

```
{
  "itemId": 0,
  "itemName": "string",
  "itemDescription": "string",
  "dueDate": "2024-03-04T13:46:48.201Z",
  "itemStatus": "string"
}
```

### 4. Delete Todo Item (For Admin only)

Specify the itemId in the URL to delete that item.

This operation is for admin accounts only, make sure that you are logged in as Admin.



