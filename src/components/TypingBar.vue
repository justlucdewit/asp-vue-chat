<template>
    <div>
        <ValidationProvider v-slot="v" rules="TooLong:500">
            <b-form-input @keydown.native="typedInInput" v-model="newMessage" type="text" id="TypingBar" :state="v.errors[0] ? false : null"></b-form-input>
            <b-button @click="sendMessage()" variant="outline-primary">send</b-button>
            <div>{{ v.errors[0] ? "message must be can not be 500 or more characters long" : ""}}</div>
        </ValidationProvider>
    </div>
</template>

<script>
    import { ValidationProvider } from "vee-validate";
    import { extend } from "vee-validate";

    extend('TooLong', {
        validate(value, args) {
            if (value.length > args.length)
                return `message cant be more then ${args.length} characters`;
            else
                return true;
        },
        params: ['length']
    });

    export default {
        props: {
            newMessage: String
        },

        components: {
            ValidationProvider
        },

        methods: {
            typedInInput: function(e) {
                if (e.which === 13) {
                    this.sendMessage();
                }
            },

            sendMessage: function() {
                if (this.newMessage.length <= 500 && this.newMessage !== ""){
                    this.$emit("onMessage", this.newMessage);
                    this.newMessage = "";
                }
            }
        }
    }
</script>

<style lang="scss">
#TypingBar{
    display: inline;
    width: 80vw;
    margin-top: 10px;
} 
</style>