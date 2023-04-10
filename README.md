# BlogApi

<div align="center">
<img src="https://user-images.githubusercontent.com/118696036/230958391-a3ba24d3-46d6-430b-bf8b-e35420e38a1e.png">
<img src="https://user-images.githubusercontent.com/118696036/230958407-ce512ea5-954c-4ff6-9a41-3ddda37952c2.png">
<img src="https://user-images.githubusercontent.com/118696036/230958419-5c97fc97-311e-4642-b770-54d5b11d0cb7.png">
</div>

## 🌐 Status
<p>Finished project ✅</p>

#
## 🧰 Prerequisites

- .NET 6.0 or +

- Connection string to SQLServer in BlogApi/appsettings.json named as Default

#
## <img src="https://icon-library.com/images/database-icon-png/database-icon-png-13.jpg" width="20" /> Database

_Create a database in SQLServer that contains the table created from the following script:_

```sql
CREATE TABLE [Blogs] (
    [BlogId] int NOT NULL IDENTITY,
    [Url] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([BlogId])
);
GO

CREATE TABLE [Posts] (
    [PostId] int NOT NULL IDENTITY,
    [Title] nvarchar(128) NOT NULL,
    [Content] nvarchar(1024) NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [BlogId] int NOT NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([PostId]),
    CONSTRAINT [FK_POST_BLOG] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([BlogId]) ON DELETE CASCADE
);
GO
```

### Relationships
```yaml
+--------------+        +-------------+
|   Blogs      | 1    * |    Posts    | 
+--------------+        +-------------+
|     BlogId   |<-------|    PostId   |
|     Url      |        |    Title    |
|              |        |   Content   |
|              |        | CreatedDate |
+--------------+        |    BlogId   |
                        +-------------+
```

#
## 🔧 Installation

`$ git clone https://github.com/lcsmota/BlogApi.git`

`$ cd BlogApi/`

`$ dotnet restore`

`$ dotnet run`

**Server listenning at  [https://localhost:7048/swagger](https://localhost:7048/swagger) or [https://localhost:7048/api/v1/Blogs](https://localhost:7048/api/v1/Blogs) and [https://localhost:7048/api/v1/Posts](https://localhost:7048/api/v1/Posts)**

#
# 📫  Routes for Blogs
### Return all objects (Blogs)
```http
  GET https://localhost:7048/api/v1/Blogs
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230959836-c4aeb794-4bae-4c36-8dfe-7cbaef15c10b.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959860-5ee11cd8-d174-495e-8907-194ac42b3d45.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230959804-7de15d22-c79e-4ad4-8804-d0084e6ef902.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959821-bc2d368f-4728-4547-b514-8f54b4592e4e.png" />

#
### Return only one object (Blog)

```http
  GET https://localhost:7048/api/v1/Blogs/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230960209-36f8f6be-201f-4e72-921d-e6e7487ab063.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959860-5ee11cd8-d174-495e-8907-194ac42b3d45.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230960221-34be50e8-0961-457d-a2d7-5de76b179bdd.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959821-bc2d368f-4728-4547-b514-8f54b4592e4e.png" />

#
### Return Blog with posts

```http
  GET https://localhost:7048/api/v1/Blogs/${id}/withposts
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230960852-41e9446f-dc46-4bf0-992d-f9814cc8e95f.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959860-5ee11cd8-d174-495e-8907-194ac42b3d45.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230960865-c78e7bf5-4285-4d74-8c5c-2256aa19a1e7.png" />
<img src="https://user-images.githubusercontent.com/118696036/230960877-f08438ce-bbfe-4d43-9365-4c9a562e371d.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959821-bc2d368f-4728-4547-b514-8f54b4592e4e.png" />

#
### Return all Blogs with Posts

```http
  GET https://localhost:7048/api/v1/Blogs/withposts
```

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230961448-9754fe43-22dd-4ef0-8d55-4d34836e178c.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230961435-1b3f9ccf-8db7-4408-a448-99363e702b58.png" />

#
### Insert a new object (Blog)

```http
  POST https://localhost:7048/api/v1/Blogs
```
📨  **body:**
```json
{
  "url": "https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx"
}
```

🧾  **response:**
```json
{
  "blogId": 11,
  "url": "https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx",
  "posts": []
}
```

⚙️  **Status Code:**
```http
  (201) - Created
  (400) - Bad Request
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230962537-616f6f73-6a97-454d-8f09-6498a62df131.png" />
<img src="https://user-images.githubusercontent.com/118696036/230962870-fad3bfe9-e24f-4260-9555-cc64de28d6ce.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230962284-9461ad7d-e0f8-4d7e-b500-ef6d6019f04f.png" />
<img src="https://user-images.githubusercontent.com/118696036/230962293-796e327e-12df-47ff-aaef-1aacf14fb768.png" />
<img src="https://user-images.githubusercontent.com/118696036/230962994-d70d00c0-0467-444e-946e-5ba4a9ba4bb2.png" />

#
### Update an object (Blog)

```http
  PUT https://localhost:7048/api/v1/Blogs/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```json
{
  "blogId": 11,
  "url": "https://entityframeworkcore.com/approach-code-first"
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
  (400) - Bad Request
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230963550-703cc058-2a5e-423f-85ee-d15e39ea8789.png" />
<img src="https://user-images.githubusercontent.com/118696036/230963562-e18fd3dd-5db5-47f2-853e-bc63b5cd5cf7.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959860-5ee11cd8-d174-495e-8907-194ac42b3d45.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230964002-d9ad2445-16a8-4ba7-a701-32c3bb9e057a.png" />
<img src="https://user-images.githubusercontent.com/118696036/230964015-5ac9a8e9-d2d5-49aa-b69c-58a8eadeeb74.png" />
<img src="https://user-images.githubusercontent.com/118696036/230964029-5ed625a4-e7fc-471d-ad02-00fcdcd369c2.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959821-bc2d368f-4728-4547-b514-8f54b4592e4e.png" />


#
### Delete an object (Blog)
```http
  DELETE https://localhost:7048/api/v1/Blogs/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to delete|

📨  **body:**

🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230964371-2401871b-b2b7-4db2-b9b6-2aba8b9b667a.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959860-5ee11cd8-d174-495e-8907-194ac42b3d45.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230964379-1cacfd7b-ee62-4e38-8062-fb77e11e56a5.png" />
<img src="https://user-images.githubusercontent.com/118696036/230959821-bc2d368f-4728-4547-b514-8f54b4592e4e.png" />


#
#
# 📫  Routes for Posts
### Return all objects (Posts)
```http
  GET https://localhost:7048/api/v1/Posts
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230966975-21427540-f2e3-48e8-b5df-bce3572e06bf.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967136-8ffe5a00-0391-460f-b85a-056fcb2bee7a.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230966984-c17a5ad1-607f-462e-a026-3aca0f2c6a02.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967271-326a0384-ccb5-41be-893d-7cb3e2fe1061.png" />

#
### Return only one object (Post)

```http
  GET https://localhost:7048/api/v1/Posts/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230967439-42fbdfa2-617b-406d-81fd-40343dcb6e80.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967136-8ffe5a00-0391-460f-b85a-056fcb2bee7a.png" />


#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230967456-6f6b2b36-64bb-455e-a266-a06a4002de10.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967271-326a0384-ccb5-41be-893d-7cb3e2fe1061.png" />


#
### Return Post with blog

```http
  GET https://localhost:7048/api/v1/Posts/${id}/withblog
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230967823-5b6436fd-7d8e-45bf-ac11-f269d3215ee2.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967136-8ffe5a00-0391-460f-b85a-056fcb2bee7a.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230967835-0f8df51b-1c6a-4654-a632-03a796164ac6.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967271-326a0384-ccb5-41be-893d-7cb3e2fe1061.png" />

#
### Return all Posts with blog

```http
  GET https://localhost:7048/api/v1/Posts/withblog
```

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230979229-804725f2-a9d7-4083-8e8f-7a3a8568c6a8.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230979374-6ae3ae27-f712-4e12-b6db-a9f81c29759f.png" />

#
### Return all Posts by blog id

```http
  GET https://localhost:7048/api/v1/Posts/blog/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230969069-0ef5ad8c-6923-4213-86fd-30e324c30ca5.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967136-8ffe5a00-0391-460f-b85a-056fcb2bee7a.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230969082-481fb153-4693-4f1e-ae36-d83332478def.png" />
<img src="https://user-images.githubusercontent.com/118696036/230969089-86bad12c-5793-44b5-b8d7-a2c629e4c5db.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967271-326a0384-ccb5-41be-893d-7cb3e2fe1061.png" />

#
### Insert a new object (Post)

```http
  POST https://localhost:7048/api/v1/Posts
```
📨  **body:**
```json
{
  "title": "Fluent API",
  "content": "Fluent API specify the model configuration that you can with data annotations as well as some additional functionality that can not be possible with data annotations.",
  "createdDate": "2023-04-10T18:37:39.440Z",
  "blogId": 2
}
```

🧾  **response:**
```json
{
    "postId": 1008,
    "title": "Fluent API",
    "content": "Fluent API specify the model configuration that you can with data annotations as well as some additional functionality that can not be possible with data annotations.",
    "createdDate": "2023-04-10T18:37:39.44Z",
    "blogId": 2
}
```

⚙️  **Status Code:**
```http
  (201) - Created
  (400) - Bad Request
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230970509-cc4acf19-c4aa-41f5-8a80-c90f60612d8a.png" />
<img src="https://user-images.githubusercontent.com/118696036/230970519-82416e31-6fdb-479a-b379-d9dd6e72b3ab.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230972385-1ffd48d4-ffa3-4217-ae4b-adc07a33e323.png" />
<img src="https://user-images.githubusercontent.com/118696036/230972413-1128f3da-8a49-4339-96f4-751cc678c49e.png" />
<img src="https://user-images.githubusercontent.com/118696036/230972424-9c824fe8-3172-417e-a6a0-f8a2e610a0ba.png" />

#
### Update an object (Post)

```http
  PUT https://localhost:7048/api/v1/Posts/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```json
{
  "postId": 1010,
  "title": "Fluent API",
  "content": "Fluent API specify the model configuration that you can with data annotations as well as some additional functionality that can not be possible with data annotations.",
  "createdDate": "2023-04-10T18:53:57.265Z",
  "blogId": 2,
  "blog": {
    "blogId": 2,
    "url": "https://entityframeworkcore.com/approach-code-first"
  }
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
  (400) - Bad Request
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230973797-340c650f-a838-4108-ad54-7e35353aed2a.png" />
<img src="https://user-images.githubusercontent.com/118696036/230973804-ab6606c5-14ba-47d2-a94c-ec9db86a31d8.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967136-8ffe5a00-0391-460f-b85a-056fcb2bee7a.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230974085-4f62af32-97c2-4b0d-88f2-ae34562b25a8.png" />
<img src="https://user-images.githubusercontent.com/118696036/230974093-c19ad6ac-afcf-413e-bc3e-439ecc6ff8ea.png" />
<img src="https://user-images.githubusercontent.com/118696036/230974102-7f639b1c-85a0-4649-a48d-cb78204f367c.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967271-326a0384-ccb5-41be-893d-7cb3e2fe1061.png" />

#
### Delete an object (Post)
```http
  DELETE https://localhost:7048/api/v1/Posts/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to delete|

📨  **body:**

🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/230974545-140c17fe-acff-48f9-ba6d-e123eeb43fa0.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967136-8ffe5a00-0391-460f-b85a-056fcb2bee7a.png" />


#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/230974573-17398904-e686-45e0-8145-ff7e5ab245fc.png" />
<img src="https://user-images.githubusercontent.com/118696036/230967271-326a0384-ccb5-41be-893d-7cb3e2fe1061.png" />

#
## 🔨 Tools used

<div>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" width=80/>
</div>

# 🖥️ Technologies and practices used
- [x] C# 10
- [x] .NET CORE 6
- [x] SQL SERVER
- [x] Entity Framework 7
- [x] Code First
- [x] Fluent API
- [x] Swagger
- [x] DTOs
- [x] Repository Pattern
- [x] Unit Of Work Pattern
- [x] Dependency injection
- [x] POO

# 📖 Features
Registration, Listing, Update and Removal

