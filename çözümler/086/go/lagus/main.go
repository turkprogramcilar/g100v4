package main

import (
  "fmt"
  "os"
  "io/ioutil"
  "strconv"
)

func readFile(file string) string {
  content, err := ioutil.ReadFile(file)

  if err != nil {
    panic(err)
  }

  return string(content)
}

const (
  PRINT_CHARACTER = '.'
)

func printCharacter(char string) {
  ascii, _ := strconv.Atoi(char)

  fmt.Print(string(ascii))
}

func isConvertible(a rune) bool {
  _, err := strconv.Atoi(string(a))

  return err == nil
}

func fieldZero(char *string, field *int, a rune) {
  if a == PRINT_CHARACTER {
    printCharacter(*char)
    *field = 0
    *char = ""
  } else if isConvertible(a) {
    *field = 1
    fieldOne(char, field, a)
  } else {
    *field = 0
  }
}

func fieldOne(char *string, field *int, a rune) {
  if isConvertible(a) {
    *char += string(a)
  } else {
    fieldZero(char, field, a)
  }
}

func interpret(code string) {
  char := ""

  /*
    0: DEFAULT
    1: NUMBER
  */
  field := 0

  for _, a := range code {
    if field == 0 {
      fieldZero(&char, &field, a)
    } else {
      fieldOne(&char, &field, a)
    }
  }
}

func main() {
  if len(os.Args) == 1 {
    fmt.Printf("Kullanım: %s [DOSYA]\n", os.Args[0])
    return
  }

  content := readFile(os.Args[1])

  interpret(content)

}

