import groovy.json.JsonOutput
import groovy.json.JsonSlurper
import java.net.HttpURLConnection
import java.net.URL

def url = new URL("https://api.example.com/endpoint")
def connection = (HttpURLConnection) url.openConnection()
connection.setRequestMethod("POST")
connection.setRequestProperty("Content-Type", "application/json")
connection.setRequestProperty("Authorization", "Bearer YOUR_JWT_TOKEN")
connection.setDoOutput(true)

def jsonBody = [
    key1: "value1",
    key2: "value2"
]

def outputStream = connection.getOutputStream()
outputStream.write(JsonOutput.toJson(jsonBody).getBytes("UTF-8"))
outputStream.close()

def responseCode = connection.getResponseCode()
println("Response Code: $responseCode")

def responseStream = connection.getInputStream()
def response = new JsonSlurper().parse(responseStream)
println("Response: $response")
responseStream.close()
