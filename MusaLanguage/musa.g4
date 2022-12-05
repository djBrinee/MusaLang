grammar musa; 

musa : (comando)+ EOF;

comando :  (asignacion) | (condicion) | (impresion) | (loopFor) | loopWhile;

loopFor : FOR SPAR asignacion (comp) INSEP 
        incremento EPAR
        SBR comando+ EBR #standardFor
        | FOR SPAR asignacion (BOOLEAN) INSEP 
        incremento EPAR
        SBR comando+ EBR #booleanFor
;

loopWhile: WHILE SEP+ SPAR (comp) EPAR SBR comando+ EBR #conditionWhile
           |
           WHILE SEP+ SPAR (BOOLEAN) EPAR SBR comando+ EBR #booleanWhile
           ;

condicion : IF SEP comp SEP+ THEN SEP* SBR 
(comando)+ EBR (else)? ;

incremento: ID SUM EQUAL NUM|ID DIF EQUAL  NUM|ID SUM SUM|ID DIF DIF;

comp : (((ID|NUM) OP (ID|NUM)));

else : ELSE SBR (comando)+ EBR ;
sent : QUOTE (PALABRA|ID)* (SEP (PALABRA|ID))* QUOTE | QUOTE NUM QUOTE ;
impresion : IMP SPAR (sent|ID) EPAR INSEP
;

asignacion : ID ASSIGN expresion INSEP #int
            | ID ASSIGN sent #string
           ;

expresion : expresion op=(SUM|DIF) termino #sumORes
          | termino                        #terminoSolo
          ;

termino : termino op=(MULT|DIV) factor #mulODiv
        | factor                      #factorSolo
        ;

factor : NUM                      #numero
       | ID                       #identificador
       | SPAR expresion EPAR      #subexpresion
       ;

FOR : 'for'; 
WHILE : 'while';
IMP : 'monta';
BOOLEAN : 'TRUE' | 'FALSE' | 'true' | 'false' ;
IF : 'if' ;
THEN : 'then' ;
ELSE : 'else' ;
NUM : [0-9]+ ;
PALABRA : NUM | NUM WORD; 
ID : [A-Za-z]+ [0-9]*;
WORD : [A-Za-z]+ ;
COMA : ',';
QUOTE : '"';
SUM : '+' ; 
DIF : '-' ;
DIV : '/' ;
MULT : '*' ;
ASSIGN : '<-';
INSEP : ';' ;
SBR : '[' ; 
EBR : ']' ;
SPAR : '(' ;
EPAR : ')' ;
SEP : ' ';
OP : '==' | '>' | '<' | '>=' | '<=' | '<>' ;
EQUAL: '=';




WS : '\n' -> skip ;
SK2 : '\r' -> skip;
SK3 : '    '+ -> skip;