import json
import random

def is_even_digit_only(number):
    if number == 0:
        return True
    number = abs(number)
    while number > 0:
        digit = number % 10
        if digit % 2 != 0:
            return False
        number //= 10
    return True

def process_array(arr):
    product = 1
    for x in arr:
        product *= x

    modified = []
    has = False
    first_index = -1
    first_value = None

    for i, x in enumerate(arr):
        if is_even_digit_only(x):
            if not has:
                has = True
                first_index = i
                first_value = x
            modified.append(product)
        else:
            modified.append(x)

    return {
        "input": arr,
        "has": has,
        "first_index": first_index,
        "first_value": first_value,
        "product": product,
        "modified": modified
    }

data = []

for _ in range(10):
    arr = [random.randint(-1000, 1000) for _ in range(5)]
    data.append(process_array(arr))

with open("generated_data.json", "w") as f:
    json.dump(data, f, indent=4)

print("Данные сгенерированы")
