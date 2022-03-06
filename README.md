
# Introduction

This is a calculator API.

You can send calculation string and it will return the results.

# Features

Supports negative numbers

Supports decimal points

# Command line screenshots (using curl from windows command prompt, not powershell)

![cmd](https://github.com/dsjosh/dot_net_core_api/blob/master/cmd.png)

# Postman screenshots

![postman](https://github.com/dsjosh/dot_net_core_api/blob/master/postman.png)

# Command line usage

```curl -X POST -H "Content-Type: application/json" http://localhost:49937/api/DoCalculation -d "\"5+1\""```

```curl -X POST -H "Content-Type: application/json" http://localhost:49937/api/DoCalculation -d "\"5-1\""```

```curl -X POST -H "Content-Type: application/json" http://localhost:49937/api/DoCalculation -d "\"5/2\""```

```curl -X POST -H "Content-Type: application/json" http://localhost:49937/api/DoCalculation -d "\"5*2\""```

# Postman usage

The link is http://localhost:49937/api/DoCalculation

Ensure "POST" method is selected

Ensure the input is sent via "Body"

Ensure "raw" format is specified

In the dropdown on the right, choose "JSON"


