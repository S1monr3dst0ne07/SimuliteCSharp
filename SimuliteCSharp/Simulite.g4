grammar Simulite;

program: line* EOF;

line: statement | ifBlock | whileBlock | block | functionDeclaration;

statement: ( assignment|functionCall ) ';';

ifBlock: 'if' '(' expression ')' block ('else' elseBlock);

elseBlock: block | ifBlock;

whileBlock: WHILE '(' expression ')' block;

functionDeclaration: 'function' IDENTIFIER '(' (IDENTIFIER (',' IDENTIFIER)*)? ')' block;

block: '{' line* '}';

constant: INTEGER | FLOAT | STRING | BOOL | NULL;

//STATEMENTS
assignment: IDENTIFIER '=' expression;

functionCall: IDENTIFIER '(' (expression (',' expression)*)? ')';

expression
    : constant                          #constantExpression
    | IDENTIFIER                        #identifierExpression
    | functionCall                      #functionCallExpression
    | expression multOp expression      #multiplicationExpression
    | expression addOp expression       #additionExpression
    | expression compareOp expression   #comparisonExpression
    | expression boolOp expression      #booleanExpression
    ;

multOp: '*' | '/'| '%';
addOp: '+' | '-';
compareOp: '!=' | '==' | '>' | '<' | '>=' | '<=';
boolOp: '&' | '|' | '^';

INTEGER: [0-9]+;
FLOAT: INTEGER '.' INTEGER;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
BOOL: 'true' | 'false';
NULL: 'null';

WHILE: 'while';
WS: [ \t\r\n]+ -> skip;
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;