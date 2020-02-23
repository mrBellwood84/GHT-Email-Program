# Secrets


Files contain classes and methods used for encryption and integrity.
__Files *will not* be published.__

A short descriptive list of classes or methods used in program will be mentioned here.

Dependency classes and methods will not.

---

1. Class KeyFileGenerator:
	* Generate a key file specified for the program.
	* Only used for generating a new key file if and when needed.
	* Will not be included in final build

2. Class KeyFile:
	* Object for key file

3. Class VerifyKeyFile:
	* Verify integrity of key file.
	* Verify content in keyfile.

4. Class KeyVector:
	* Get and hold Key and IV for AES encryption from key file.

5. Class Password
	* Salting and hashing the password using the key file.
	* Verify password

6. Class Encryptor
	* Used to encrypt string before saved to config file
	* Decrypt string when loading from config file

7. Class HashCollection
	* Hold methods for computing hashes
---

*I can send a zip file with exluded content by mail by request if needed ^^*