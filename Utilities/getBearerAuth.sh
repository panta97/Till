#!/bin/bash

curl -H "Content-Type: application/json" -X POST -d '{"username": "olsen", "password": "password"}' http://localhost:5000/api/auth/login | ruby -r json -e 'puts JSON.parse($<.read)["tokenString"];' | awk '{print "Bearer "$1}' | tr -d '\n' | pbcopy
``